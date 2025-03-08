export interface CommitmentDetails {
  name: string;
  commitments: CommitmentDto[];
  assetClasses: AssetClassDto[];
}

export interface CommitmentDto {
  id: number;
  assetClass: string;
  amount: string;
  currency: string;
}

export interface AssetClassDto {
  name: string;
  totalAmount: string;
}