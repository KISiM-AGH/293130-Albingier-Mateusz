import React from 'react';
import RecipesList from './Components/RecipesList' 
import TOP_BAR from './Components/TOP_BAR'
import { Route, BrowserRouter } from 'react-router-dom'
import Recipe from './Components/Recipe'
import Home from './Components/Home'


function App() {
  return (
    <BrowserRouter>
      <div className="App">
      < TOP_BAR/>
      <Route exact path='/' component={Home}/>
      <Route exact path='/recipes' component={RecipesList}/>
      <Route path='/recipes/:recipe_id' component={Recipe}/>
      </div>
    </BrowserRouter>
  );
}

export default App;
