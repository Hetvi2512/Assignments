import React, { useState } from "react";
import { useDispatch } from "react-redux";
import Button from "@material-ui/core/Button";
import { Input } from "@material-ui/core";
import { FormControl } from "@material-ui/core";
import SaveIcon from "@material-ui/icons/Save";
import { addTodo } from "../redux";

export default function TodoInput() {
  const [name, setName] = useState("");
  const dispatch = useDispatch();
  return (
    <div>
      <div>
        <Input
          id="name"
          onChange={(e) => {
            setName(e.target.value);
          }}
        />
        <Button
          variant="contained"
          color="primary"
          size="small"
          startIcon={<SaveIcon />}
          onClick={() => {
            console.log("Clcik");
            dispatch(
              addTodo({
                id: Date.now(),
                name: name,
                isCompleted: false,
                isVisible: true,
              })
            );
          }}
        >
          Save
        </Button>
      </div>
    </div>
  );
}
