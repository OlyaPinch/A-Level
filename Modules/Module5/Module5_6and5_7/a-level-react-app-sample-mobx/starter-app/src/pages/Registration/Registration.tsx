import React, { useState } from 'react';
import {observer} from "mobx-react-lite";
import { TextField, Button, Typography, Box } from '@mui/material';
import {IRegisterUser} from "../../interfaces/RegisterUser";




const Registration= () => {
   // const store = new RegistrationStore(appStore.authStore);
    const [name, setName] = useState('');
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const [confirmPassword, setConfirmPassword] = useState('');
    const [errors, setErrors] = useState<string[]>([]);

    const handleNameChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        setName(event.target.value);
    };

    const handleEmailChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        setEmail(event.target.value);
    };

    const handlePasswordChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        setPassword(event.target.value);
    };

    const handleConfirmPasswordChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        setConfirmPassword(event.target.value);
    };

    const validateForm = (): boolean => {
        const validationErrors: string[] = [];

        if (!name.trim()) {
            validationErrors.push('Name is required');
        }

        if (!email.trim()) {
            validationErrors.push('Email is required');
        } else if (!isValidEmail(email)) {
            validationErrors.push('Invalid email address');
        }

        if (!password.trim()) {
            validationErrors.push('Password is required');
        }
        
        

        if (!confirmPassword.trim()) {
            validationErrors.push('Confirm password is required');
        } else if (password !== confirmPassword) {
            validationErrors.push('Passwords do not match');
        }

        setErrors(validationErrors);

        return validationErrors.length === 0;
    };

    const handleSubmit = (event: React.FormEvent) => {
        event.preventDefault();

        if (validateForm()) {
            const newUser: IRegisterUser = {
                name,
                email,
                password,
            };

           // store.Registration(newUser)
            
        }
    };

    const isValidEmail = (email: string): boolean => {
        // Basic email validation regex pattern
        const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
        return emailRegex.test(email);
    };

    return (
      
    <Box
        sx={{
            marginTop: 8,
            display: 'flex',
            flexDirection: 'column',
            alignItems: 'center',
        }}
    >
        <Typography component="h1" variant="h5">
            Registration
        </Typography>
        <form onSubmit={handleSubmit}>
            <TextField
                label="Name"
                margin="normal"
                value={name}
                onChange={handleNameChange}
                fullWidth
            />
            <TextField
                label="Email"
                margin="normal"
                value={email}
                onChange={handleEmailChange}
                fullWidth
            />
            <TextField
                type="password"
                label="Password"
                margin="normal"
                value={password}
                onChange={handlePasswordChange}
                fullWidth
            />
            <TextField
                type="password"
                margin="normal"
                label="Confirm Password"
                value={confirmPassword}
                onChange={handleConfirmPasswordChange}
                fullWidth
            />
            {errors.map((error, index) => (
                <Typography key={index} color="error">
                    {error}
                </Typography>
            ))}
            <Button  type="submit" variant="contained" color="primary">
                Register
            </Button>
        </form>
    </Box>
    );
}

export default Registration;
