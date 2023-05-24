import React, {ReactElement, FC, useContext} from "react";
import {Box, Button, CircularProgress, Grid, Typography} from "@mui/material";
import {AppStoreContext} from "../../App";

import { useNavigate } from "react-router-dom";


const Logout: FC<any> = (): ReactElement => {
    const appStore = useContext(AppStoreContext);
    const navigate = useNavigate();
    const handleLogout = () => {
        appStore.authStore.logout();
        navigate("/");
    };
    return (

        <Grid container spacing={5} direction="column"  justifyContent="center"
              alignItems="center">
            <Grid item xs={4}>
                <Typography variant="h3">Do you really want to LogOut?</Typography>
            </Grid>
            <Grid item xs={4}>
                <Button
                    type="submit"
                    fullWidth
                    variant="contained"
                    sx={{ mt: 3, mb: 2 }}
                    onClick={handleLogout}
                >
                    Logout
                </Button>
            </Grid>
          
        </Grid>
       
    );
};

export default Logout ;