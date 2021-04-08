import React, { useState } from "react";
import { useDispatch } from "react-redux";
import { Delete, Build, Save } from "@material-ui/icons";
import IconButton from "@material-ui/core/IconButton";

import { makeStyles } from "@material-ui/core/styles";
import {
  ListItem,
  Paper,
  Grid,
  ListItemText,
  ListItemSecondaryAction,
} from "@material-ui/core";

import Checkbox from "@material-ui/core/Checkbox";

import { deleteTodo, editTodo, markTodo } from "../redux";

import EditRoundedIcon from "@material-ui/icons/EditRounded";

const useStyles = makeStyles((theme) => ({
  root: {
    flexGrow: 1,
  },
  paper: {
    padding: theme.spacing(2),
    textAlign: "center",
    color: theme.palette.text.secondary,
  },
}));

export default function TodoItem({ todo }) {
  const classes = useStyles();
  const dispatch = useDispatch();
  const [edit, setEdit] = useState(false);
  const [name, setName] = useState(todo.name);
  const handleCheck = () => {
    dispatch(markTodo(todo));
  };
  console.log(todo);
  return (
    <div>
      <div>
        <Paper style={{ margin: 16 }}>
          <ListItem>
            <Checkbox
              checked={todo.isCompleted}
              color="primary"
              onChange={handleCheck}
            />
            <ListItemText>
              {edit ? (
                <input
                  type="text"
                  value={name}
                  onChange={(e) => {
                    setName(e.target.value);
                  }}
                  minLength="3"
                />
              ) : (
                <div>{todo.name}</div>
              )}
            </ListItemText>
            <IconButton
              onClick={() => {
                dispatch(
                  editTodo({
                    todo,
                    name: name,
                  })
                );
                if (editTodo) {
                  console.log("IF");
                  setName(name);
                }
                setEdit(!edit);
              }}
              variant="contained"
              color="primary"
              style={{ width: "10%" }}
              // startIcon={<EditRoundedIcon />}
            >
              {edit ? (
                <Save fontSize="small" />
              ) : (
                <EditRoundedIcon fontSize="small" />
              )}
            </IconButton>
            {/* <Button
              variant="contained"
              color="secondary"
              style={{ width: "10%" }}
              startIcon={<DeleteIcon />}
              onClick={() => dispatch(deleteTodo(todo))}
           />*/}
            <IconButton
              color="secondary"
              onClick={() => dispatch(deleteTodo(todo))}
            >
              <Delete fontSize="small" />
            </IconButton>
          </ListItem>
        </Paper>
      </div>
    </div>
  );
}
