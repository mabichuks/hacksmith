import { Fragment } from "react";
import {
  Button,
  Checkbox,
  Divider,
  FormControlLabel,
  TextField,
  Typography,
} from "@mui/material";
import Head from "next/head";
import LoginPageStyles from "../styles/Home.module.css";
import Header from "../components/Header/Header";
import Link from "next/link";
import { Form, Formik } from "formik";

const defaultValues = {
  emailAddress: "",
  password: "",
};

type ILoginValues = {
  emailAddress: string;
  password: string;
};

const handleSubmit = (values: ILoginValues) => {
  console.log("Logging in....", values);
};

const LoginPage = () => {
  return (
    <>
      <Head>
        <title>Sign in to Watchlist</title>
        <meta name="description" content="Login Page" />
        <meta name="viewport" content="width=device-width, initial-scale=1" />
        <link rel="icon" href="/favicon.ico" />
      </Head>
      <Header />
      <Fragment>
        <div className={LoginPageStyles.homepage}>
          <div className={LoginPageStyles.loginContainer}>
            <div className={LoginPageStyles.flexContainer} />
            <div className={LoginPageStyles.card}>
              <div style={{ width: "420px" }}>
                <Formik initialValues={defaultValues} onSubmit={handleSubmit}>
                  {(props) => (
                    <Form>
                      <Typography mt={4} className={LoginPageStyles.labelText}>
                        {" "}
                        Email Address
                      </Typography>
                      <TextField
                        id="outlined-required"
                        placeholder="Email address"
                        fullWidth
                        name="emailAddress"
                        required
                        onChange={props.handleChange}
                      />
                      <Typography mt={4} className={LoginPageStyles.labelText}>
                        Password
                      </Typography>
                      <TextField
                        id="outlined-required"
                        placeholder="Password"
                        fullWidth
                        name="password"
                      />
                      <FormControlLabel
                        control={
                          <Checkbox
                            sx={{
                              color: "#ffffff",
                              "&.Mui-checked": {
                                color: "#F05423",
                              },
                            }}
                          />
                        }
                        label="Remember Me"
                      />
                      <Button
                        className={LoginPageStyles.loginButton}
                        type="submit"
                      >
                        Login
                      </Button>
                      <Divider color={"#FFFFFF"} />
                      <Typography mt={4} className={LoginPageStyles.labelText}>
                        Do you want to signup?
                      </Typography>
                      <Button>Sign Up</Button>
                    </Form>
                  )}
                </Formik>
              </div>
            </div>
          </div>
        </div>
      </Fragment>
    </>
  );
};

export default LoginPage;
