import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import {
  Table,
  TableBody,
  TableCell,
  TableContainer,
  TableHead,
  TableRow,
  Paper,
  MenuItem,
  Select,
  Typography,
  Container,
  Box,
} from "@mui/material";
import {
  CommitmentDetails,
  Commitment, AssetClass,
} from "../types/commitment";

const CommitmentsGrid = () => {
  const { investorId } = useParams<{ investorId: string }>(); 
  const [name, setName] = useState<string>("");
  const [commitments, setCommitments] = useState<Commitment[]>([]);
  const [assetClasses, setAssetClasses] = useState<AssetClass[]>([]);
  const [filteredAssetClass, setFilteredAssetClass] = useState<string>("");
  

  useEffect(() => {
    const fetchCommitments = async () => {
      try {
        const response = await fetch(
          `${import.meta.env.VITE_API_BASE_URL}/default/${investorId}`
        );
        const data: CommitmentDetails = await response.json();
        setName(data.name);
        setCommitments(data.commitments);
        setAssetClasses(data.assetClasses);
      } catch (error) {
        console.error("Error fetching commitments:", error);
      }
    };

    if (investorId) {
      fetchCommitments();
    }
  }, [investorId]);

  const filteredCommitments = filteredAssetClass
    ? commitments.filter((c) => c.assetClass === filteredAssetClass)
    : commitments;

  return (
    <Container>
      <Box sx={{ mb: 2 }}>
        <Typography variant="h4">{name} - Commitments</Typography>

        <Select
          value={filteredAssetClass}
          onChange={(e) => setFilteredAssetClass(e.target.value)}
          displayEmpty
          fullWidth
          sx={{ mt: 1, mb: 2 }}
        >
          <MenuItem value="">All Asset Classes</MenuItem>
          {assetClasses.map((assetClass) => (
            <MenuItem key={assetClass.name} value={assetClass.name}>
              {assetClass.name} ({assetClass.totalAmount} GBP)
            </MenuItem>
          ))}
        </Select>
      </Box>

      <TableContainer
        component={Paper}
        sx={{ minHeight: "400px", maxHeight: "600px", overflowY: "auto" }}
      >
        <Table>
          <TableHead>
            <TableRow>
              <TableCell>ID</TableCell>
              <TableCell>Asset Class</TableCell>
              <TableCell>Amount</TableCell>
              <TableCell>Currency</TableCell>
            </TableRow>
          </TableHead>
          <TableBody sx={{ height: "100%" }}>
            {filteredCommitments.length > 0 ? (
              filteredCommitments.map((commitment) => (
                <TableRow key={commitment.id}>
                  <TableCell>{commitment.id}</TableCell>
                  <TableCell>{commitment.assetClass}</TableCell>
                  <TableCell>{commitment.amount}</TableCell>
                  <TableCell>{commitment.currency}</TableCell>
                </TableRow>
              ))
            ) : (
              <TableRow>
                <TableCell colSpan={4} align="center">
                  No Commitments Available
                </TableCell>
              </TableRow>
            )}
          </TableBody>
        </Table>
      </TableContainer>
    </Container>
  );
};

export default CommitmentsGrid;
