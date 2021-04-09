import React from "react";
import Container from "@material-ui/core/Container";

import { makeStyles } from "@material-ui/core/styles";
import TodoInput from "../components/TodoInput.component";
import TodoList from "../components/TodoList.component";
import TodoFooter from "../components/TodoFooter.component";
import { AppBar, Toolbar, Typography, Paper } from "@material-ui/core";

const useStyles = makeStyles({
  root: {
    marginTop: 5,
    marginBottom: 10,
    padding: 10,
    boxShadow:
      "0px 3px 5px -1px rgba(0,0,0,0.2), 0px 6px 10px 0px rgba(0,0,0,0.14), 0px 1px 18px 0px rgba(0,0,0,0.12)",
  },
  button: {
    marginTop: 16,
  },
});
export default function Todo() {
  const classes = useStyles();
  return (
    <div>
      <Container
        //maxWidth="sm"
        className={classes.root}
        style={{ backgroundColor: "#efefef" }}
      >
        <h2>Your Todo List</h2>
        <TodoInput />
        <TodoList />
        <br />
        <TodoFooter />
      </Container>
    </div>
  );
}
