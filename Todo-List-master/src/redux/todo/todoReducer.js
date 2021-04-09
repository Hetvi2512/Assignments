import {
  ADD_TODO,
  DELETE_TODO,
  EDIT_TODO,
  IS_COMPLETED,
  COMPLETED,
  INCOMPLETE,
  ALL,
} from "./todoType";
import { todos } from "../todoData";

const todoReducer = (state = todos, action) => {
  let newTodos;
  let id;
  switch (action.type) {
    case ADD_TODO:
      newTodos = [...state];
      newTodos.push(action.payload);

      return newTodos;

    case EDIT_TODO:
      newTodos = [...state];

      id = newTodos.indexOf(action.payload.todo);

      /*    newTodos.forEach(item=>{
        if(item.id==action.payload.id){
          item.name = action.payload.name
          
        }
      })*/

      if (id !== -1) {
        newTodos[id].name = action.payload.name;
      }

      return newTodos;

    case DELETE_TODO:
      newTodos = [...state];
      newTodos.splice(newTodos.indexOf(action.payload), 1);
      return newTodos;

    case IS_COMPLETED:
      newTodos = [...state];
      id = newTodos.indexOf(action.payload);

      if (action.payload.isCompleted === true) {
        newTodos[id].isCompleted = false;
      } else {
        newTodos[id].isCompleted = true;
      }
      return newTodos;
    case ALL:
      const totalList = state.map((item) => {
        return { ...item, isVisible: true };
      });
      return totalList;

    case COMPLETED:
      newTodos = [...state];
      const completedList = newTodos.map((item) => {
        return !item.isCompleted
          ? { ...item, isVisible: false }
          : { ...item, isVisible: true };
      });
      return completedList;
    case INCOMPLETE:
      newTodos = [...state];

      const activeList = newTodos.map((item) => {
        return item.isCompleted
          ? { ...item, isVisible: false }
          : { ...item, isVisible: true };
      });
      return activeList;

    default:
      return state;
  }
};
export default todoReducer;
