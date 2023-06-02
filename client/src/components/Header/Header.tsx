import * as React from "react";
import AppBar from "@mui/material/AppBar";
import Box from "@mui/material/Box";
import IconButton from "@mui/material/IconButton";
import Toolbar from "@mui/material/Toolbar";
import MukuruLogo from "../../../public/icons/mu-rewards-logo.svg";
import Image from "next/image";
import Link from "next/link";

export default function Header() {
  return (
    <Box sx={{ flexGrow: 1 }}>
      <AppBar position="static">
        <Toolbar>
          <IconButton
            size="large"
            edge="start"
            color="inherit"
            aria-label="menu"
            sx={{ mr: 2 }}
          ></IconButton>
          <Link href="/">
            <Image src={MukuruLogo} alt="Icons" width={150} height={50} />
          </Link>
        </Toolbar>
      </AppBar>
    </Box>
  );
}
