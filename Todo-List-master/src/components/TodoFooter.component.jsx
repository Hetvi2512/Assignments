import React from "react";
import { useDispatch, useSelector } from "react-redux";
import { allTodo, completedTodo, incompleteTodo } from "../redux";
import Button from "@material-ui/core/Button";
export default function TodoFooter() {
  let todos = useSelector(state => state.todo);
  
  const dispatch = useDispatch();

  return (
    <div>
      <Button variant="outlined" onClick={() => dispatch(allTodo(todos))}>
        All
      </Button>
      <Button
        variant="outlined"
        color="primary"
        onClick={() => dispatch(completedTodo(todos))}
      >
        Completed
      </Button>
      <Button
        variant="outlined"
        color="secondary"
        onClick={() => dispatch(incompleteTodo(todos))}
      >
        Incomplete
      </Button>
    </div>
  );
}
