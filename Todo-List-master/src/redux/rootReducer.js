import { combineReducers } from "redux";
import todoReducer from "./todo/todoReducer";
import filterReducer from "./filters/filterReducer"
const rootReducer = combineReducers({
  todo: todoReducer,
  filter:filterReducer,
});
export default rootReducer;
