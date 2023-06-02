/* eslint-disable jsx-a11y/anchor-is-valid */
import Stack from "@mui/material/Stack";
import styles from "../styles/reward.module.css";
import { Formik, Form } from "formik";
import {
  Box,
  Button,
  CardContent,
  Chip,
  Divider,
  Grid,
  Typography,
} from "@mui/material";
import {
  DataGrid,
  GridColDef,
  GridValueGetterParams,
  GridRowSelectionModel,
} from "@mui/x-data-grid";
import Head from "next/head";
import Header from "@/components/Header/Header";
import { useRouter } from "next/router";
import { useState, useEffect } from "react";
import { IEmployeeData } from "./home";
import { ToastContainer, toast } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";
import axios from "axios";

const rows = [
  {
    id: "sdjo412293bdk",
    item: "https://i.postimg.cc/HJnv1BdP/image-4.png",
    detail: "Mukuru Branded Hoodie",
    muPoint: 300,
  },
  {
    id: "27dauduebca2ka",
    item: "https://i.postimg.cc/dhCpDm9g/uberEats.png",
    detail: "Uber Eats",
    muPoint: 100,
  },
  {
    id: "034h-dhwida",
    item: "https://i.postimg.cc/7bLRSyV3/gift-card.png",
    detail: "Gift Card",
    muPoint: 100,
  },
  {
    id: "74ndladw-dfo",
    item: "https://i.postimg.cc/DS6fMywP/mug.jpg",
    detail: "Mukuru Branded Mug",
    muPoint: 25,
  },
];

type IRedeemBody = {
  userId: string | string[] | undefined;
  items: [
    {
      ItemId: string;
      Quantity: number;
    }
  ];
};

const RedeemComponent = () => {
  const router = useRouter();
  const [newData, setNewData] = useState<IEmployeeData>();
  const data = router.query;

  async function handleRedeemSubmit(values: { selectedItems: any }) {
    const body: IRedeemBody = {
      userId: "",
      items: [],
    };

    values.selectedItems.map((item: { id: any }) => {
      (body.userId = data.Id || newData?.Id),
        body.items.push({
          ItemId: item.id,
          Quantity: 1,
        });
    });

    axios
      .post("http://localhost:5021/api/v1/checkout", body)
      .then((response) => {
        console.log(response);
      });

    console.log(body);

    toast(
      "Thank you. You redeem request has been sent for further processing.",
      {
        position: "top-right",
        autoClose: 3000,
        hideProgressBar: false,
        closeOnClick: true,
        pauseOnHover: true,
        draggable: true,
        progress: undefined,
        theme: "light",
      }
    );

    const push = () => {
      router.push("/home");
    };

    setTimeout(push, 4000);
  }

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

  //   useEffect(() => {
  //     fetch(`https://api.github.com/users/eunit99/repos`)
  //       .then((response) => response.json())
  //       .then((usefulData) => {
  //         console.log(usefulData);
  //         setApiData(usefulData);
  //       })
  //       .catch((e) => {
  //         console.error(`An error occurred: ${e}`);
  //       });
  //   });

  const onRowsSelectionHandler = (
    e: GridRowSelectionModel,
    setFieldValue: any
  ) => {
    const selectedIDs = new Set(e);
    const selectedRows = rows.filter((r) => selectedIDs.has(r.id));
    console.log(selectedRows);
    setFieldValue("selectedItems", selectedRows, true);
  };

  const columns: GridColDef[] = [
    {
      field: "id",
      headerName: "ID",
      sortable: false,
      headerClassName: "super-app-theme--header",
      width: 250,
      hideable: true,
    },
    {
      field: "item",
      headerName: "Item",
      headerClassName: "super-app-theme--header",
      width: 300,
      sortable: false,
      renderCell: (params) => {
        return (
          <Grid item xs={12} sm={12}>
            <img src={params.row.item} alt="Icons" width={65} height={65} />
          </Grid>
        );
      },
    },
    {
      field: "detail",
      headerName: "Detail",
      headerClassName: "super-app-theme--header",
      sortable: false,
      width: 550,
      valueGetter: (params: GridValueGetterParams) => `${params.row.detail}`,
    },
    {
      field: "muPoint",
      headerName: "MuPoint",
      headerClassName: "super-app-theme--header",
      width: 464,
      sortable: false,
      valueGetter: (params: GridValueGetterParams) => `${params.row.muPoint}`,
    },
  ];

  return (
    <>
      <Head>
        <title>Reward MuPoints</title>
      </Head>
      <Header />
      <Box className={styles.main}>
        <Grid className={styles.redeemContainer}>
          <Stack className={styles.headerSection}>
            <h1>Reward MuPoints - Catalogue</h1>
          </Stack>
          <Box sx={{ display: "flex", color: "#000000", marginTop: "35px" }}>
            <Typography variant="h5" gutterBottom sx={{ marginRight: "10px" }}>
              {`My MuPoints`}
            </Typography>
            <Chip
              label={data?.earnedPoints || newData?.earnedPoints}
              color="primary"
            />
          </Box>
        </Grid>
        <Divider color={"#000000"} />
        <Grid className={styles.tableSection}>
          {rows && (
            <CardContent>
              <Box
                sx={{
                  height: 500,
                  width: "100%",
                  "& .super-app-theme--header": {
                    backgroundColor: "#f05423",
                    color: "#ffffff",
                    fontWeight: "600",
                    textTransform: "uppercase",
                    textAlign: "center",
                  },
                }}
              >
                <Formik
                  initialValues={{ selectedItems: [] }}
                  onSubmit={handleRedeemSubmit}
                >
                  {(props) => (
                    <Form id="redeem">
                      <Grid item xs={12} className={styles.hideDisplay}></Grid>
                      <DataGrid
                        rows={rows}
                        columns={columns}
                        autoHeight
                        checkboxSelection
                        onRowSelectionModelChange={(e: GridRowSelectionModel) =>
                          onRowsSelectionHandler(e, props.setFieldValue)
                        }
                      />
                      <Button className={styles.rewardButton} type="submit">
                        Redeem
                      </Button>
                    </Form>
                  )}
                </Formik>
              </Box>
            </CardContent>
          )}
        </Grid>
        <ToastContainer />
      </Box>
    </>
  );
};

export default RedeemComponent;
