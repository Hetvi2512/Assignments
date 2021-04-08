import { COMPLETED, INCOMPLETE, ALL } from "./filterType";

import { todos } from "../todoData";
const filterReducer = (state = todos, action) => {
  let newTodos;
  switch (action.type) {
    case ALL:
      newTodos = [...action.payload];
      return newTodos;

    case COMPLETED:
      console.log("KO")
      newTodos = [...state];
      const completedList = newTodos.map((item)=>{
        return(
          (!item.isCompleted)?{...item, isVisible:false}:{...item, isVisible:true}
        )
      })
      console.log(completedList)
      return completedList;
      case INCOMPLETE:
      newTodos = [...state];
     
      const activeList = newTodos.map((item)=>{
        return(
          (item.isCompleted)?{...item, isVisible:false}:{...item, isVisible:true}
        )
      })
      console.log(activeList)
      return activeList;
     default:
      return state;
  }
};
export default filterReducer;
