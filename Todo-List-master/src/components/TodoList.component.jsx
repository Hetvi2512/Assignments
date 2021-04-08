import React from "react";
import TodoItem from "./TodoItem.component";
import { useDispatch, useSelector } from "react-redux";
import { allTodo, completedTodo, incompleteTodo } from "../redux";
import Button from "@material-ui/core/Button";
export default function TodoList() {
  let todos = useSelector((state) => state.todo);

  const dispatch = useDispatch();

  return (
    <div>
      <h3>Your Todo List</h3>

      {todos.map((todo) => {
        return todo.isVisible && <TodoItem key={todo.id} todo={todo} />;
      })}
    </div>
  );
}
