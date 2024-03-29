import React, {FC, ReactElement, useContext} from "react";
import {
  Box,
  Link,
  Container,
  IconButton,
  Menu,
  MenuItem,
  Toolbar,
  Typography,
} from "@mui/material";
import MenuIcon from "@mui/icons-material/Menu";
import { routes } from "../../routes";
import { NavLink } from "react-router-dom";
import {AppStoreContext} from "../../App";
import {observer} from "mobx-react-lite";
import AuthStore from "../../stores/AuthStore";


const Navbar: FC = (): ReactElement => {
  const appStore = useContext(AppStoreContext);


  const [anchorElNav, setAnchorElNav] = React.useState(null);

  const handleOpenNavMenu = (event: any) => {
    setAnchorElNav(event.currentTarget);
  };

  const handleCloseNavMenu = () => {
    setAnchorElNav(null);
  };

  return (
    <Box
      sx={{
        width: "100%",
        height: "auto",
        backgroundColor: "secondary.main",
      }}
    >
      <Container maxWidth="xl">
        <Toolbar disableGutters>
          <Typography
            variant="h6"
            noWrap
            sx={{
              mr: 2,
              display: { xs: "none", md: "flex" },
            }}
          >
            {!!appStore.authStore.token ? (
                <span
                    style={{ color: 'green' }}>{`Token is: ${appStore.authStore.token}`}</span>
            ) : 'A-LEVEL CURSE'}
          </Typography>
          <Box sx={{ flexGrow: 1, display: { xs: "flex", md: "none" } }}>
            <IconButton
              size="large"
              aria-label="account of current user"
              aria-controls="menu-appbar"
              aria-haspopup="true"
              onClick={handleOpenNavMenu}
              color="inherit"
            >
              <MenuIcon />
            </IconButton>
            <Menu
              id="menu-appbar"
              anchorEl={anchorElNav}
              anchorOrigin={{
                vertical: "bottom",
                horizontal: "left",
              }}
              keepMounted
              transformOrigin={{
                vertical: "top",
                horizontal: "left",
              }}
              open={Boolean(anchorElNav)}
              onClose={handleCloseNavMenu}
              sx={{
                display: { xs: "block", md: "none" },
              }}
            >
              {routes.map((page) => (
              !!page.enabled && <Link
                  key={page.key}
                  component={NavLink}
                  to={page.path}
                  color="black"
                  underline="none"
                  variant="button"
                >
                  <MenuItem onClick={handleCloseNavMenu}>
                    <Typography textAlign="center">{page.title}</Typography>
                  </MenuItem>
                </Link>
              ))}
            </Menu>
          </Box>
          <Typography
            variant="h6"
            noWrap
            component="div"
            sx={{ flexGrow: 1, display: { xs: "flex", md: "none" } }}
          >
            {!!appStore.authStore.token ? (
                <span
                    style={{ color: 'green' }}>{`Token is: ${appStore.authStore.token}`}</span>
            ) : 'A-LEVEL CURSE'}
          </Typography>
          <Box sx={{ flexGrow: 1, display: { xs: "none", md: "flex" } }}>
            <Box
              sx={{
                display: "flex",
                flexDirection: "row",
                justifyContent: "flex-start",
                alignItems: "center",
                marginLeft: "1rem",
              }}
            >
              {
                  routes.map((page) => (
               !!page.enabled && page.key!=='login-route' && page.key!=='logout-route' && page.key!=='registration-route'  && <Link
                  key={page.key}
                  component={NavLink}
                  to={page.path}
                  color="black"
                  underline="none"
                  variant="button"
                  sx={{ fontSize: "large", marginLeft: "2rem" }}
                >
                  {page.title}
                </Link>                 
                  
              ) )                
                  
              
              
              }
            </Box>
              <Box
                  sx={{
                      display: "flex",
                      flexDirection: "row",
                      justifyContent: "flex-end",
                      alignItems: "center",
                      marginLeft: "1rem",
                  }}
              >
                  {
                      routes.map((page) => (
                          !!page.enabled && !!!appStore.authStore.token   && (page.key==='login-route' || page.key==='registration-route')  && <Link
                              key={page.key}
                              component={NavLink}
                              to={page.path}
                              color="black"
                              underline="none"
                              variant="button"
                              sx={{ fontSize: "large", marginLeft: "2rem" }}
                          >
                              {page.title}
                          </Link>

                      ) )



                  }
              </Box>
              <Box
                  sx={{
                      display: "flex",
                      flexDirection: "row",
                      justifyContent: "flex-end",
                      alignItems: "center",
                      marginLeft: "1rem",
                  }}
              >
                  {
                      routes.map((page) => (
                          !!page.enabled && !!appStore.authStore.token   && (page.key==='logout-route')  && <Link
                              key={page.key}
                              component={NavLink}
                              to={page.path}
                              color="black"
                              underline="none"
                              variant="button"
                              sx={{ fontSize: "large", marginLeft: "2rem" }}
                          >
                              {page.title}
                          </Link>

                      ) )



                  }
              </Box>
              
              
          </Box>
        </Toolbar>
      </Container>
    </Box>
  );
};

export default observer(Navbar);
