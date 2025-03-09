export interface CommitmentDetails {
  name: string;
  commitments: Commitment[];
  assetClasses: AssetClass[];
}

export interface Commitment {
  id: number;
  assetClass: string;
  amount: string;
  currency: string;
}

export interface AssetClass {
  name: string;
  totalAmount: string;
}