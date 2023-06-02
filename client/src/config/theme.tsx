import { createTheme } from "@mui/material/styles";
import { red } from "@mui/material/colors";
import { Inter } from "next/font/google";

const inter = Inter({ subsets: ["latin"] });
// Create a theme instance.
const theme = createTheme({
  palette: {
    primary: {
      main: "#F05423",
    },
    secondary: {
      main: "#4B4B4B",
    },
    error: {
      main: red.A400,
    },
  },
  typography: {
    fontFamily: inter.style.fontFamily,
  },
});
export default theme;
