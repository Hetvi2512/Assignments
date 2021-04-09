import React, { useState } from "react";
import { useDispatch } from "react-redux";
import { Delete, Build, Save } from "@material-ui/icons";
import IconButton from "@material-ui/core/IconButton";
import { Input } from "@material-ui/core";
import { makeStyles } from "@material-ui/core/styles";
import {
  ListItem,
  Paper,
  Grid,
  ListItemText,
  TextField,
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

  const [error, setError] = useState(false);
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
            <ListItemText style={{ overflow: "auto" }}>
              {edit ? (
                <TextField
                  type="text"
                  value={name}
                  required={true}
                  variant="outlined"
                  onChange={(e) => {
                    setName(e.target.value);
                  }}
                  style={{ width: "50%" }}
                />
              ) : (
                <div>{todo.name}</div>
              )}
            </ListItemText>
            <IconButton
              onClick={() => {
                if (!name.trim()) {
                  setError(true);

                  return;
                }
                dispatch(
                  editTodo({
                    todo,
                    name: name,
                  })
                );
                if (editTodo) {
                  setError(false);
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

            <IconButton
              color="secondary"
              onClick={() => dispatch(deleteTodo(todo))}
            >
              <Delete fontSize="small" />
            </IconButton>
          </ListItem>
          {error ? (
            <p
              className="error"
              style={{ color: "red", textAlign: "left", marginLeft: "5%" }}
            >
              You must enter a value!
            </p>
          ) : (
            <></>
          )}
        </Paper>
      </div>
    </div>
  );
}
