import React, { Component } from 'react'
import { Grid, Typography, Paper } from "@material-ui/core";
import { Card, CardContent } from "@material-ui/core";
import axios from 'axios';
import Button from '@material-ui/core/Button'
import EDIT from "./EDIT.js"
import { Link } from "react-router-dom"

class Recipe extends Component {
    state = {
        oldRecipe: [],
    }

    componentDidMount() {
        axios.get('http://localhost:8080/recipes/' + this.props.match.params.recipe_id).then((response) => {
            this.setState({
                oldRecipe: response.data
            })
        });
    }

    deleteAction = () => {
        axios.delete("http://localhost:8080/recipes/" + this.state.oldRecipe.id)
        .then()
    }

    render() {
        return (
            <div className="container" style={{ marginTop: 20, padding: 30 }}>
                <Paper elevation={3}>
                    <Grid container spacing={3} justify="center">
                        <Card style={{ width: "auto"}}>
                            <CardContent>
                                <Typography gutterBottom variant="h5" component="h2">
                                    {this.state.oldRecipe.title}
                                </Typography>
                                <Typography component="p">{this.state.oldRecipe.recipe}</Typography>
                            </CardContent>
                        </Card>
                    </Grid>
                    <Link to="/recipes">
                    <Button color='secondary' onClick={this.deleteAction}>DELETE</Button>
                    </Link>
                    <EDIT recipe_id={this.state.oldRecipe.id}/>
                </Paper>
            </div>
        )
    }
}

export default Recipe;