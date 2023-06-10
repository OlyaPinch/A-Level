﻿import {Card, CardActionArea, CardContent, CardMedia, Typography} from "@mui/material"
import {FC, ReactElement} from "react";
import {IResource} from "../../../../interfaces/resources";
import {useNavigate} from "react-router-dom";

const ResourceCard: FC<IResource> = (props): ReactElement => {

    const navigate = useNavigate()

    return (
        <Card sx={{ maxWidth: 250, backgroundColor:props.color }}>
            <CardActionArea onClick={() => navigate(`/resource/${props.id}`)}>
                
                <CardContent>
                    <Typography noWrap gutterBottom variant="h6" component="div">
                        {props.name}
                    </Typography>
                    <Typography variant="body2" color="text.secondary" >
                        {props.pantone_value} {props.year}
                    </Typography>
                </CardContent>
                
            </CardActionArea>
        </Card>
    )
}

export default ResourceCard