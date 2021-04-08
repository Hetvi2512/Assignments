import { COMPLETED, INCOMPLETE, ALL } from "./filterType";

export function allTodo(todos) {
    return {
      type:ALL,
      payload: todos,
    };
  }
  export function completedTodo(todos) {
   console.log("OK")
    return {
      type:COMPLETED,
      payload: todos,
    };
  }
  export function incompleteTodo(todos) {
    return {
      type:INCOMPLETE,
      payload: todos,
    };
  }