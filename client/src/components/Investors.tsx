import { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";
import { Typography, Card, CardContent, Grid, Container, TextField } from "@mui/material";
import { Investor } from "../types/investor";

const Investors = () => {
  const [investors, setInvestors] = useState<Investor[]>([]);
  const [searchText, setSearchText] = useState("");
  const navigate = useNavigate();

  useEffect(() => {
    const fetchInvestors = async () => {
      try {
        const response = await fetch(
          `${import.meta.env.VITE_API_BASE_URL}/default`
        );
        const data: Investor[] = await response.json();
        setInvestors(data);
      } catch (error) {
        console.error("Error fetching investors:", error);
      }
    };
    fetchInvestors();
  }, []);

  const filteredInvestors = searchText
    ? investors.filter((i) => i.name.toLowerCase().trim().includes(searchText.toLowerCase().trim()))
    : investors;

  return (
    <Container>
      <Typography variant="h4">
        Investors
      </Typography>
      <TextField
        sx={{ width: "500px", margin: "50px" }}
        type="text"
        value={searchText}
        onChange={(e) => setSearchText(e.target.value)}
      />
      <Grid container spacing={3}>
        {filteredInvestors.map((investor) => (
          <Grid item xs={12} sm={6} md={4} key={investor.id}>
            <Card
              onClick={() => navigate(`/commitments/${investor.id}`)}
              sx={{ cursor: "pointer", p: 2 }}
            >
              <CardContent>
                <Typography variant="h6">{investor.name}</Typography>
                <Typography variant="body2">Type: {investor.type}</Typography>
                <Typography variant="body2">
                  Country: {investor.country}
                </Typography>
                <Typography variant="body2">
                  Total Commitment: {investor.totalCommitment}
                </Typography>
              </CardContent>
            </Card>
          </Grid>
        ))}
      </Grid>
    </Container>
  );
};

export default Investors;
