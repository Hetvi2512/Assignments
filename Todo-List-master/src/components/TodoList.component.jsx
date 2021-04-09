import React from "react";
import TodoItem from "./TodoItem.component";
import { useDispatch, useSelector } from "react-redux";

export default function TodoList() {
  let todos = useSelector((state) => state.todo);
  let list = [];
  todos.map((todo) => {
    {
      todo.isVisible && list.push(todo);
    }
  });
  return (
    <div>
      {todos.map((todo) => {
        return (
          todo.isVisible && (
            <>
              <TodoItem key={todo.id} todo={todo} />
            </>
          )
        );
      })}
      <p className="totalTask"> Total task in the List: {list.length}</p>
    </div>
  );
}
