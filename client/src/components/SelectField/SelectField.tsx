import React from "react";
import { FieldHookConfig, useField } from "formik";
import { FormControl, FormControlProps, MenuItem } from "@mui/material";
import TextField, {
  BaseTextFieldProps,
  TextFieldProps,
} from "@mui/material/TextField";

export interface ISelectFieldProps {
  label?: string;
  data: { value: string | number; label: string | number }[];
}

type ISelectField = ISelectFieldProps &
  TextFieldProps &
  BaseTextFieldProps &
  FieldHookConfig<string> &
  FormControlProps;

function SelectField(props: ISelectField) {
  const { label, data, ...others } = props;
  const [field, meta] = useField(props);
  const { value: selectedValue } = field;

  return (
    <FormControl {...others}>
      <TextField
        {...field}
        {...others}
        value={selectedValue ? selectedValue : ""}
        select
        label={label}
      >
        <MenuItem disabled value="">
          {`select ${props.label || props.placeholder}`}
        </MenuItem>
        {data.map((item, index: number) => (
          <MenuItem key={index} value={item.value}>
            {item.label}
          </MenuItem>
        ))}
      </TextField>
    </FormControl>
  );
}

export default SelectField;
