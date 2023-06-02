/* eslint-disable jsx-a11y/anchor-is-valid */
import Stack from "@mui/material/Stack";
import styles from "../styles/reward.module.css";
import { Formik, Form, FormikHelpers } from "formik";
import CircularProgress from "@mui/material/CircularProgress";
import {
  Box,
  Button,
  CardContent,
  Divider,
  Grid,
  TextField,
} from "@mui/material";
import { useState } from "react";
import { DataGrid, GridColDef, GridValueGetterParams } from "@mui/x-data-grid";
import Head from "next/head";
import Header from "@/components/Header/Header";
import SelectField from "@/components/SelectField/SelectField";
import { MUKURU_VALUES, MUPOINTS } from "@/constants";
import { useRouter } from "next/router";
import { ToastContainer, toast } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";

const defaultValues = {
  muPoints: "",
  mukuruValues: "",
};

const rows = [{ id: 1, name: "Snow" }];

const EmployeeSearch = () => {
  const router = useRouter();
  const [loading, setLoading] = useState<boolean>(false);

  async function handleSubmit(
    values: { searchInput: string },
    actions: FormikHelpers<{ searchInput: string }>
  ) {
    actions.setSubmitting(true);
    console.log(values);
    actions.setSubmitting(false);
  }

  async function handleRewardSubmit(values: {
    muPoints: number;
    mukuruValues: string;
    comments: string;
  }) {
    const body = {
      points: values.muPoints,
      values: values.mukuruValues,
      name: rows[0].name,
    };
    console.log(body);

    toast("Thank you. Your rewards request has been sent.", {
      position: "top-right",
      autoClose: 3000,
      hideProgressBar: false,
      closeOnClick: true,
      pauseOnHover: true,
      draggable: true,
      progress: undefined,
      theme: "light",
    });
    const push = () => {
      router.push("/home");
    };

    setTimeout(push, 4000);
  }

  const columns: GridColDef[] = [
    {
      field: "id",
      headerName: "Employee ID",
      sortable: false,
      headerClassName: "super-app-theme--header",
      width: 250,
    },
    {
      field: "name",
      headerName: "Employee Name",
      headerClassName: "super-app-theme--header",
      width: 300,
      sortable: false,
      valueGetter: (params: GridValueGetterParams) => `${params.row.name}`,
    },
    {
      field: "values",
      headerName: "Select Mukuru Values",
      headerClassName: "super-app-theme--header",
      sortable: false,
      width: 550,
      renderCell: () => {
        return (
          <Grid item xs={12} sm={12}>
            <SelectField
              className={styles.selectField}
              data={MUKURU_VALUES}
              name={"mukuruValues"}
              fullWidth
              label={"Mukuru Values"}
            />
          </Grid>
        );
      },
    },
    {
      field: "points",
      headerName: "Select MuPoints",
      headerClassName: "super-app-theme--header",
      width: 550,
      sortable: false,
      renderCell: () => {
        return (
          <Grid item xs={12} sm={12}>
            <SelectField
              className={styles.selectField}
              data={MUPOINTS}
              name={"muPoints"}
              fullWidth
              label={"MuPoints"}
            />
          </Grid>
        );
      },
    },
  ];

  return (
    <>
      <Head>
        <title>Reward MuPoints</title>
      </Head>
      <Header />
      <Box className={styles.main}>
        <Grid className={styles.container}>
          <Stack className={styles.headerSection}>
            <h1>Reward MuPoints</h1>
          </Stack>
        </Grid>
        <Divider color={"#000000"} />
        <Grid className={styles.cardSection}>
          <Formik initialValues={{ searchInput: "" }} onSubmit={handleSubmit}>
            {(props) => (
              <Form id="searchForm">
                <Grid item xs={12} sm={12} className={styles.searchSection}>
                  <Grid item xs={12} sm={12} className={styles.searchField}>
                    <TextField
                      name="searchInput"
                      label="Search Employee with name or email address"
                      fullWidth
                      type="search"
                      onChange={props.handleChange}
                    />
                  </Grid>
                  <Grid className={styles.buttonSection}>
                    <Button
                      className={styles.searchButton}
                      type="submit"
                      disabled={props.isSubmitting}
                    >
                      {"Search"}
                    </Button>
                  </Grid>
                </Grid>
                {loading && (
                  <Box>
                    <CircularProgress color="primary" />
                  </Box>
                )}
              </Form>
            )}
          </Formik>
        </Grid>
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
                  initialValues={defaultValues}
                  onSubmit={handleRewardSubmit}
                >
                  {() => (
                    <Form id="rewards">
                      <DataGrid
                        rows={rows}
                        columns={columns}
                        disableRowSelectionOnClick
                        autoHeight
                      />
                      <Button className={styles.rewardButton} type="submit">
                        Reward
                      </Button>
                    </Form>
                  )}
                </Formik>
              </Box>
            </CardContent>
          )}
          <ToastContainer />
        </Grid>
      </Box>
    </>
  );
};

export default EmployeeSearch;
