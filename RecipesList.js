import React, { useState, useEffect } from "react";
import axios from "axios";

import { Grid, Typography, Paper } from "@material-ui/core";
import { Card, CardActionArea, CardContent } from "@material-ui/core";
import { Link } from "react-router-dom"

import FAB_BOTTOM from './FAB_BOTTOM'

function RecipesList() {
  const [recipes, setRecipes] = useState([]);

  useEffect(() => {
    async function fetchRecipes() {
      const res = await axios.get("http://localhost:8080/recipes");
      setRecipes(res.data);
    }
    fetchRecipes();
  }, []);

  return (
    <div style={{ marginTop: 20, padding: 30 }}>
      <Paper elevation={3}>
        <Grid container spacing={3} justify="center">
          {recipes.map((recipe) => (
            <Grid item="xs" key={recipe.id} color="secondary">
              <Card style={{width: "250px"}}>
                <CardActionArea component={Link} to={'/recipes/' + recipe.id}>
                  <CardContent>
                    <Typography gutterBottom variant="h5" component="h2">
                      {recipe.title}
                    </Typography>
                    <Typography component="p">{recipe.recipe}</Typography>
                  </CardContent>
                </CardActionArea>
              </Card>
            </Grid>
          ))}
        </Grid>
        <FAB_BOTTOM />
      </Paper>
    </div>
  );
}

export default RecipesList;
