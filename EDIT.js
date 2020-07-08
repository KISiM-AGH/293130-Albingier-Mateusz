import React, { Component } from "react";
import Button from "@material-ui/core/Button";
import Dialog from "@material-ui/core/Dialog";
import AppBar from "@material-ui/core/AppBar";
import Toolbar from "@material-ui/core/Toolbar";
import IconButton from "@material-ui/core/IconButton";
import Typography from "@material-ui/core/Typography";
import CloseIcon from "@material-ui/icons/Close";
import TextField from "@material-ui/core/TextField";
import { Grid } from "@material-ui/core";
import Euro from "@material-ui/icons/Euro";
import Timer from "@material-ui/icons/Timer";
import axios from 'axios';


class EDIT extends Component {

    constructor(props) {
        super(props)
        this.state = {
            oldRecipe: [],
            title:'',
            recipe:'',
            time:0,
            price:0,
            open: false,
        }
    }

    handleOpen = () => {
        this.setState({ open: true });
        axios.get('http://localhost:8080/recipes/' + this.props.recipe_id).then((response) => {
            this.setState({
                oldRecipe: response.data
            })
            console.log(response.data)
        });
    };

    handleClose = () => {
        this.setState({ open: false });
    };

    handleSubmit = () => {
        var titl = this.state.title
        var recip = this.state.recipe
        var tim = this.state.time
        var pric = this.state.price
        axios.put("http://localhost:8080/recipes/" + this.props.recipe_id, {titl, recip, tim, pric})
            .catch(function (error) { console.log(error) })
            .then(response => { console.log(response) })

        this.handleClose();
    };

    render() {
        return (
            <div>
                <Button onClick={this.handleOpen}>Edit recipe</Button>

                <Dialog
                    open={this.state.open}
                    onClose={this.handleClose}
                    fullScreen="true">

                    <AppBar>
                        <Toolbar>
                            <IconButton
                                edge="start"
                                color="inherit"
                                onClick={this.handleClose}
                                aria-label="close">
                                <CloseIcon />
                            </IconButton>
                            <Typography variant="h6">
                                Edit recipe
                                </Typography>
                            <Button autoFocus color="inherit" onClick={this.handleSubmit}>
                                Save
                                </Button>
                        </Toolbar>
                    </AppBar>

                    <form noValidate autoComplete="off" onSubmit={this.handleSubmit}>

                    <Grid container spacing={1} alignItems="flex-end">
                            <Grid item>
                                <TextField
                                    defaultValue={this.state.oldRecipe.title}
                                    onChange={(e) => this.setState({title: e.target.value })}
                                    id="input-with-icon-grid"
                                    label="Title"
                                    multiline
                                    name="title"
                                />
                            </Grid>
                        </Grid>

                        <Grid container spacing={1} alignItems="flex-end">
                            <Grid item>
                                <TextField
                                    defaultValue={this.state.oldRecipe.recipe}
                                    onChange={(e) => this.setState({recipe: e.target.value })}
                                    id="input-with-icon-grid"
                                    label="How it is made"
                                    multiline
                                    name="recipe"
                                />
                            </Grid>
                        </Grid>

                        <Grid container spacing={1} alignItems="flex-end">
                            <Grid item>
                                <Timer />
                            </Grid>
                            <Grid item>
                                <TextField
                                    defaultValue={this.state.oldRecipe.time}
                                    onChange={(e) => this.setState({time: e.target.value })}
                                    id="time"
                                    label="Time to cook"
                                    name="time"
                                />
                            </Grid>
                        </Grid>

                        <Grid container spacing={1} alignItems="flex-end">
                            <Grid item>
                                <Euro />
                            </Grid>
                            <Grid item>
                                <TextField
                                    defaultValue={this.state.oldRecipe.price}
                                    onChange={(e) => this.setState({price: e.target.value })}
                                    id="input-with-icon-grid"
                                    label="Cost of one portion in euro"
                                    name="price"
                                />
                            </Grid>
                        </Grid>

                    </form>
                </Dialog>
            </div>
        )
    }

}

export default EDIT