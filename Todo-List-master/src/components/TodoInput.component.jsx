import React, { useState } from "react";
import { useDispatch } from "react-redux";
import Button from "@material-ui/core/Button";
import { Input } from "@material-ui/core";
import { makeStyles } from "@material-ui/core/styles";
import { Grid, Paper } from "@material-ui/core";
import SaveIcon from "@material-ui/icons/Save";
import { addTodo } from "../redux";
import { Block } from "@material-ui/icons";

export default function TodoInput() {
  const [name, setName] = useState("");
  const [error, setError] = useState(false);
  const styles = {
    Button: {
      margin: 10,
    },
    Paper: {
      margin: "auto",
      padding: 10,
      alignItems: "center",
      marginTop: 10,
      width: "96%",
    },
  };
  const dispatch = useDispatch();
  return (
    <div>
      <div>
        <Paper style={styles.Paper}>
          <Input
            id="name"
            style={{ width: "70%" }}
            placeholder="Enter your tasks"
            onChange={(e) => {
              setName(e.target.value);
            }}
          />

          <Button
            variant="contained"
            color="primary"
            size="small"
            style={styles.Button}
            startIcon={<SaveIcon />}
            onClick={() => {
              if (!name.trim()) {
                setError(true);

                return;
              }
              dispatch(
                addTodo({
                  id: Date.now(),
                  name: name,
                  isCompleted: false,
                  isVisible: true,
                })
              );
              setError(false);
            }}
          >
            Add
          </Button>
          {error ? (
            <p className="error" style={{ display: "block", color: "red" }}>
              Error, must enter a value!
            </p>
          ) : (
            <></>
          )}
        </Paper>
      </div>
    </div>
  );
}
