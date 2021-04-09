import {
  ADD_TODO,
  DELETE_TODO,
  EDIT_TODO,
  IS_COMPLETED,
  COMPLETED,
  INCOMPLETE,
  ALL,
} from "./todoType";

export function addTodo(todos) {
  return {
    type: ADD_TODO,
    payload: todos,
  };
}
export function deleteTodo(todosId) {
  return {
    type: DELETE_TODO,
    payload: todosId,
  };
}
export function editTodo(todo) {
  return {
    type: EDIT_TODO,
    payload: todo,
  };
}

export function markTodo(todo) {
  return {
    type: IS_COMPLETED,
    payload: todo,
  };
}
export function allTodo(todos) {
  return {
    type: ALL,
    payload: todos,
  };
}
export function completedTodo(todos) {
  return {
    type: COMPLETED,
    payload: todos,
  };
}
export function incompleteTodo(todos) {
  return {
    type: INCOMPLETE,
    payload: todos,
  };
}
