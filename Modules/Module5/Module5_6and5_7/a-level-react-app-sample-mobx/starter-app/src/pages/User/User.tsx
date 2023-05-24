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
import * as userApi from "../../api/modules/users"
import {IUser} from "../../interfaces/users";
import {useParams} from "react-router-dom";
import LoginStore from "../Login/LoginStore";
import UserStore from "./UserStore";
import {AppStoreContext} from "../../App";

const User: FC<any> = (): ReactElement => {
    const [user, setUser] = useState<IUser | null>(null)
    const [isLoading, setIsLoading] = useState<boolean>(false)
    const { id } = useParams()
    const appStore = useContext(AppStoreContext);
    const store = new UserStore(appStore.authStore);
    const [email,setEmail] = useState(store.email);
    const [firstName,setFirstName] = useState(store.firstName);
    const [lastName,setLastName] = useState(store.lastName);

    useEffect(() => {
        setEmail(store.email)
        setFirstName(store.firstName)
        setLastName(store.lastName)
        
       
        if (id) {
            const getUser = async () => {
                try {
                    setIsLoading(true)
                    const res = await userApi.getById(id)
                   
                    
                    setUser(res.data)
                    setEmail(res.data.email);
                   // debugger;
                    setFirstName(res.data.first_name);
                    setLastName(res.data.last_name);
                   
                   
                } catch (e) {
                    if (e instanceof Error) {
                        console.error(e.message)
                    }
                }
                setIsLoading(false)
            }
            getUser()
        }
    }, [id,store.email,store.firstName,store.lastName])

    return (
        <Container>
            <Grid container spacing={4} justifyContent="center" m={4}>
                {isLoading ? (
                    <CircularProgress />
                ) : (
                    <>
                        
                        <Grid item xs={4}>
                            <Card sx={{ maxWidth: 250 }}>
                                <CardMedia
                                    component="img"
                                    height="250"
                                    image={user?.avatar}
                                    alt={user?.email}
                                />
                                <CardContent>
                                    <Typography noWrap gutterBottom variant="h6" component="div">
                                        {user?.email}
                                    </Typography>
                                    <Typography variant="body2" color="text.secondary">
                                        {user?.first_name} {user?.last_name}
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
                                        value={firstName}
                                        onChange={(event) => setFirstName(event.target.value)}
                                        autoFocus
                                    />
                                    <TextField
                                        margin="normal"
                                        required
                                        fullWidth
                                        id="lastNam"
                                        label="LastName"
                                        name="LastNam"
                                        
                                        value={lastName}                                        
                                        onChange={event=> setLastName(event.target.value)}
                                        autoFocus
                                    />
                                    <TextField
                                        margin="normal"
                                        required
                                        fullWidth
                                        name="email"
                                        label="Email"
                                        type="email"
                                        id="email"
                                        onChange={(event) => setEmail(event.target.value)}
                                        value={email}
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

export default User;