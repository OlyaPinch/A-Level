import React, {ReactElement, FC, useEffect, useState, useContext} from "react";
import {
    Box, Button,
    Card,
    CardContent,
    CardMedia,
    CircularProgress,
    Container,

    Grid,


    Pagination,

    Typography
} from '@mui/material'
import IconButton from '@mui/material/IconButton';
import Input from '@mui/material/Input';
import FilledInput from '@mui/material/FilledInput';
import OutlinedInput from '@mui/material/OutlinedInput';
import InputLabel from '@mui/material/InputLabel';
import InputAdornment from '@mui/material/InputAdornment';
import FormHelperText from '@mui/material/FormHelperText';
import FormControl from '@mui/material/FormControl';
import TextField from '@mui/material/TextField';
import Visibility from '@mui/icons-material/Visibility';
import VisibilityOff from '@mui/icons-material/VisibilityOff';
import * as resourceApi from "../../api/modules/resources"
import {IUser} from "../../interfaces/users";
import {useParams} from "react-router-dom";
import LoginStore from "../Login/LoginStore";
import UserStore from "./ResourceStore";
import {AppStoreContext} from "../../App";
import {IResource} from "../../interfaces/resources";
import ResourceStore from "./ResourceStore";

const Resource: FC<any> = (): ReactElement => {
    const [resource, setResource] = useState<IResource | null>(null)
    const [isLoading, setIsLoading] = useState<boolean>(false)
    const { id } = useParams()
    const appStore = useContext(AppStoreContext);
    const store = new ResourceStore(appStore.authStore);

    useEffect(() => {
        if (id) {
            const getResource = async () => {
                try {
                    setIsLoading(true)
                    const res = await resourceApi.getById(id)
                    setResource(res.data)
                } catch (e) {
                    if (e instanceof Error) {
                        console.error(e.message)
                    }
                }
                setIsLoading(false)
            }
            getResource()
        }
    }, [id])

    return (
        <Container>
            <Grid container spacing={4} justifyContent="center" m={4}>
                {isLoading ? (
                    <CircularProgress />
                ) : (
                    <>
                        
                        <Grid item xs={4}>
                            <Card sx={{ maxWidth: 250, backgroundColor: resource?.color }}>
                                
                                <CardContent>
                                    <Typography noWrap gutterBottom variant="h6" component="div">
                                        {resource?.name}
                                    </Typography>
                                    <Typography variant="body2" color="text.secondary">
                                        {resource?.year} {resource?.pantone_value}
                                    </Typography>
                                </CardContent>
                            </Card>
                        </Grid>
                        <Grid item xs={8}>
                            <Box
                                sx={{
                                    marginTop: 8,
                                    display: 'flex',
                                    flexDirection: 'column',
                                    alignItems: 'center',
                                }}
                            >
                                <Typography component="h1" variant="h5">
                                    Update
                                </Typography>
                                <Box component="form"
                                     onSubmit={async (event) =>
                                     {
                                         event.preventDefault()

                                     }}
                                     noValidate sx={{ mt: 1 }}>
                                    <TextField
                                        margin="normal"
                                        required
                                        fullWidth
                                        id="name"
                                        label="Name"
                                        name="Name"
                                        value={resource?.name}
                                      //  onChange={(event) => setFirstName(event.target.value)}
                                        autoFocus
                                    />
                                    <TextField
                                        margin="normal"
                                        required
                                        fullWidth
                                        id="year"
                                        label="Year"
                                        name="Year"

                                        value={resource?.year}
                                       // onChange={event=> setLastName(event.target.value)}
                                        autoFocus
                                    />
                                    <TextField
                                        margin="normal"
                                        required
                                        fullWidth
                                        name="Pantone_value"
                                        label="pantone_value"
                                        type="text"
                                        id="pantone_value"
                                        //onChange={(event) => setEmail(event.target.value)}
                                        value={resource?.pantone_value}
                                    />
                                    <TextField
                                        margin="normal"
                                        required
                                        fullWidth
                                        name="Color"
                                        label="color"
                                        type="color"
                                        id="Color"
                                        //onChange={(event) => setEmail(event.target.value)}
                                        value={resource?.color}
                                    />
                                    {!!store.error && (
                                        <p style={{ color: 'red', fontSize: 14 }}>{store.error}</p>
                                    )}
                                    <Button
                                        type="submit"
                                        fullWidth
                                        variant="contained"
                                        sx={{ mt: 3, mb: 2 }}
                                    >
                                        {store.isLoading ? (
                                            <CircularProgress />
                                        ) : (
                                            'Update'
                                        )}
                                    </Button>
                                    {!!appStore.authStore.token && (
                                        <p className="mt-3 mb-3" style={{ color: 'green', fontSize: 14, fontWeight: 700 }}>{`Success! Token is: ${appStore.authStore.token}`}</p>
                                    )}
                                </Box>
                            </Box>
                        </Grid>
                        
                       
                    </>
                )}
            </Grid>
        </Container>
    );
};

export default Resource;