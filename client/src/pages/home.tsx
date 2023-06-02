import { Fragment, useEffect, useState } from "react";
import Head from "next/head";
import ProfileStyles from "../styles/profile.module.css";
import Header from "../components/Header/Header";
import { useRouter } from "next/router";
import { Box, Button, Chip, Link, Typography } from "@mui/material";
import Rewards from "../../public/icons/reward.png";
import Award from "../../public/icons/award.png";
import Kudos from "../../public/icons/kudos.png";
import Image from "next/image";
import { push } from "@/utils";

export interface IEmployeeData {
  name: string;
  earnedPoints: number;
  id: string;
  isAdmin: string;
}

const HomePage = () => {
  const [newData, setNewData] = useState<IEmployeeData>();
  const router = useRouter();
  const data = router.query;
  const handleClick = () => {
    if (data.name !== undefined) {
      localStorage.setItem("employeeData", JSON.stringify(data));
    } else {
      localStorage.setItem("employeeData", JSON.stringify(newData));
    }
    push(router, "/redeem", data.name !== undefined ? data : newData);
  };

  const logout = () => {
    localStorage.removeItem("employeeData");
    router.push(`/`);
  };

  useEffect(() => {
    if (data.name !== undefined) {
      localStorage.setItem("employeeData", JSON.stringify(data));
    } else {
      const employeeData = JSON.parse(
        localStorage?.getItem("employeeData") as string
      );
      localStorage.setItem("employeeData", JSON.stringify(employeeData));
      setNewData(employeeData);
    }
  }, []);

  return (
    <>
      <Head>
        <title>Home Page</title>
        <meta name="description" content="Login Page" />
        <meta name="viewport" content="width=device-width, initial-scale=1" />
        <link rel="icon" href="/favicon.ico" />
      </Head>
      <Header />
      <Fragment>
        {data.name !== undefined ? (
          <Box className={ProfileStyles.homepage}>
            <Typography
              variant="h3"
              gutterBottom
              className={ProfileStyles.text}
            >
              {`Welcome ${data.name || newData?.name}`}
            </Typography>

            {data.isAdmin !== "false" ? (
              <Box className={ProfileStyles.rewardSection}>
                <Box>
                  <Image src={Rewards} alt="Icons" width={200} height={200} />
                  <Link href={"/reward"} underline="hover">
                    {"Reward MuPoints"}
                  </Link>
                </Box>

                <Box>
                  <Image src={Award} alt="Icons" width={200} height={200} />
                  <Link href={"#"} underline="hover">
                    {"Award"}
                  </Link>
                </Box>
                <Box>
                  <Image src={Kudos} alt="Icons" width={200} height={200} />
                  <Link href={"#"} underline="hover">
                    {"Kudos"}
                  </Link>
                </Box>
              </Box>
            ) : (
              <Box className={ProfileStyles.rewardSection}>
                <Box>
                  <Image src={Kudos} alt="Icons" width={200} height={200} />
                  <Link href={"#"} underline="hover">
                    {"Kudos"}
                  </Link>
                </Box>
              </Box>
            )}
            <Box
              sx={{
                paddingTop: "70px",
                marginBottom: "50px",
              }}
            >
              <Typography
                variant="h4"
                gutterBottom
                className={ProfileStyles.text}
              >
                {`My MuPoints`}
              </Typography>
              <Button
                className={ProfileStyles.redeemButton}
                onClick={handleClick}
              >
                Redeem MuPoints
              </Button>
            </Box>
            {data.isAdmin !== "false" ? (
              <Box
                sx={{
                  display: "flex",
                  justifyContent: "space-between",
                  width: "800px",
                  margin: "0 auto",
                }}
              >
                <Box sx={{ display: "flex", color: "#ffffff" }}>
                  <Typography
                    variant="h5"
                    gutterBottom
                    className={ProfileStyles.pointsText}
                  >
                    {`Earned`}
                  </Typography>
                  <Chip
                    label={data.earnedPoints || newData?.earnedPoints}
                    color="primary"
                    className={ProfileStyles.muPoints}
                  />
                </Box>
                <Box sx={{ display: "flex", color: "#ffffff" }}>
                  <Typography
                    variant="h5"
                    gutterBottom
                    className={ProfileStyles.pointsText}
                  >
                    {`Rewarded`}
                  </Typography>
                  <Chip
                    label={data.earnedPoints || newData?.earnedPoints}
                    color="primary"
                    className={ProfileStyles.muPoints}
                  />
                </Box>
              </Box>
            ) : (
              <Box
                sx={{
                  display: "flex",
                  justifyContent: "center",
                  margin: "0 auto",
                }}
              >
                <Box sx={{ display: "flex", color: "#ffffff" }}>
                  <Typography
                    variant="h5"
                    gutterBottom
                    className={ProfileStyles.pointsText}
                  >
                    {`Earned`}
                  </Typography>
                  <Chip
                    label={data.earnedPoints || newData?.earnedPoints}
                    color="primary"
                    className={ProfileStyles.muPoints}
                  />
                </Box>
              </Box>
            )}
            <Button onClick={logout} className={ProfileStyles.logoutButton}>
              Logout
            </Button>
          </Box>
        ) : (
          <Box className={ProfileStyles.homepage}>
            <Typography
              variant="h3"
              gutterBottom
              className={ProfileStyles.text}
            >
              {`Welcome ${newData?.name}`}
            </Typography>

            {newData?.isAdmin !== "false" ? (
              <Box className={ProfileStyles.rewardSection}>
                <Box>
                  <Image src={Rewards} alt="Icons" width={200} height={200} />
                  <Link href={"/reward"} underline="hover">
                    {"Reward MuPoints"}
                  </Link>
                </Box>

                <Box>
                  <Image src={Award} alt="Icons" width={200} height={200} />
                  <Link href={"#"} underline="hover">
                    {"Award"}
                  </Link>
                </Box>
                <Box>
                  <Image src={Kudos} alt="Icons" width={200} height={200} />
                  <Link href={"#"} underline="hover">
                    {"Kudos"}
                  </Link>
                </Box>
              </Box>
            ) : (
              <Box className={ProfileStyles.rewardSection}>
                <Box>
                  <Image src={Kudos} alt="Icons" width={200} height={200} />
                  <Link href={"#"} underline="hover">
                    {"Kudos"}
                  </Link>
                </Box>
              </Box>
            )}
            <Box
              sx={{
                paddingTop: "70px",
                marginBottom: "50px",
              }}
            >
              <Typography
                variant="h4"
                gutterBottom
                className={ProfileStyles.text}
              >
                {`My MuPoints`}
              </Typography>
              <Button
                className={ProfileStyles.redeemButton}
                onClick={handleClick}
              >
                Redeem MuPoints
              </Button>
            </Box>
            {newData?.isAdmin !== "false" ? (
              <Box
                sx={{
                  display: "flex",
                  justifyContent: "space-between",
                  width: "800px",
                  margin: "0 auto",
                }}
              >
                <Box sx={{ display: "flex", color: "#ffffff" }}>
                  <Typography
                    variant="h5"
                    gutterBottom
                    className={ProfileStyles.pointsText}
                  >
                    {`Earned`}
                  </Typography>
                  <Chip
                    label={newData?.earnedPoints}
                    color="primary"
                    className={ProfileStyles.muPoints}
                  />
                </Box>
                <Box sx={{ display: "flex", color: "#ffffff" }}>
                  <Typography
                    variant="h5"
                    gutterBottom
                    className={ProfileStyles.pointsText}
                  >
                    {`Rewarded`}
                  </Typography>
                  <Chip
                    label={newData?.earnedPoints}
                    color="primary"
                    className={ProfileStyles.muPoints}
                  />
                </Box>
              </Box>
            ) : (
              <Box
                sx={{
                  display: "flex",
                  justifyContent: "center",
                  margin: "0 auto",
                }}
              >
                <Box sx={{ display: "flex", color: "#ffffff" }}>
                  <Typography
                    variant="h5"
                    gutterBottom
                    className={ProfileStyles.pointsText}
                  >
                    {`Earned`}
                  </Typography>
                  <Chip
                    label={newData?.earnedPoints}
                    color="primary"
                    className={ProfileStyles.muPoints}
                  />
                </Box>
              </Box>
            )}
            <Button onClick={logout} className={ProfileStyles.logoutButton}>
              Logout
            </Button>
          </Box>
        )}
      </Fragment>
    </>
  );
};

export default HomePage;
