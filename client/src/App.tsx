import { BrowserRouter, Route, Routes } from "react-router-dom";
import "./App.css";
import Investors from "./components/Investors";
import Commitment from "./components/Commitment";

function App() {
  return (
    <BrowserRouter>
      {" "}
      <Routes>
        <Route path="/" element={<Investors />} />
        <Route path="/commitments/:investorId" element={<Commitment />} />
      </Routes>
    </BrowserRouter>
  );
}

export default App;
