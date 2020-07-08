import React, { useState } from "react";
import { makeStyles } from "@material-ui/core/styles";
import Fab from "@material-ui/core/Fab";
import AddIcon from "@material-ui/icons/Add";
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
import axios from 'axios'
import { Link } from "react-router-dom"


const useStyles = makeStyles((theme) => ({
  fab: {
    margin: 0,
    top: "auto",
    right: 20,
    bottom: 20,
    left: "auto",
    position: "fixed",
    color: "primary",
  },
  appBar: {
    position: "relative",
  },
  title: {
    marginLeft: theme.spacing(0),
    flex: 1,
  },
  form: {
    "& .MuiTextField-root": {
      margin: theme.spacing(1),
      width: "100%",
      height: "100%"
    },
  },
  dialog: {
    fullWidth: true,
    maxWidth: 'xl'
  }
}));

function FloatingActionButton() {
  const classes = useStyles();
  const [open, setOpen] = useState(false);

  const [newTitle, setTitle] = useState("");
  const [newRecipe, setRecipe] = useState("");
  const [newPrice, setPrice] = useState(0);
  const [newTime, setTime] = useState(0);

  const handleOpen = () => {
    setOpen(true);
  };

  const handleClose = () => {
    setOpen(false);
  };

  const handleSubmit = (e) => {
    e.preventDefault();

    axios.post("http://localhost:8080/recipes", {
      "title": newTitle,
      "recipe": newRecipe,
      "time": newTime,
      "price": newPrice
    }).then(response => {
      console.log(response.data)
    })
    handleClose();
  };

  return (
    <div>
      <Fab color="secondary" className={classes.fab} onClick={handleOpen}>
        <AddIcon />
      </Fab>
      <Dialog
        className={classes.dialog}
        open={open}
        onClose={handleClose}
        aria-labelledby="form-dialog-title"
        fullScreen="true">
        <AppBar className={classes.appBar}>
          <Toolbar>
            <IconButton
              edge="start"
              color="inherit"
              onClick={handleClose}
              aria-label="close">
              <CloseIcon />
            </IconButton>
            <Typography variant="h6" className={classes.title}>
              Add new recipe
            </Typography>
            <Link to="/recipes">
              <Button autoFocus color="secondary" onClick={handleSubmit}>
                Save
            </Button>
            </Link>

          </Toolbar>
        </AppBar>
        <form className={classes.form} noValidate autoComplete="off" onSubmit={handleSubmit}>

          <Grid container spacing={1} alignItems="flex-end">
            <Grid item>
              <TextField
                value={newTitle}
                onChange={(e) => { setTitle(e.target.value) }}
                id="input-with-icon-grid"
                label="Title"
                multiline
              />
            </Grid>
          </Grid>

          <Grid container spacing={1} alignItems="flex-end">
            <Grid item>
              <TextField
                value={newRecipe}
                onChange={(e) => { setRecipe(e.target.value) }}
                id="input-with-icon-grid"
                label="How it is made"
                multiline
              />
            </Grid>
          </Grid>

          <Grid container spacing={1} alignItems="flex-end">
            <Grid item>
              <Timer />
            </Grid>
            <Grid item>
              <TextField
                value={newTime}
                onChange={(e) => { setTime(e.target.value) }}
                id="time"
                label="Time to cook"
              />
            </Grid>
          </Grid>

          <Grid container spacing={1} alignItems="flex-end">
            <Grid item>
              <Euro />
            </Grid>
            <Grid item>
              <TextField
                value={newPrice}
                onChange={(e) => { setPrice(e.target.value) }}
                id="input-with-icon-grid"
                label="Cost of one portion in euro"
              />
            </Grid>
          </Grid>

        </form>
      </Dialog>
    </div>
  );
}

export default FloatingActionButton;
