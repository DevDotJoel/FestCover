export type InputFormProps = {
  name: string;
  label: string;
  control: any;
  errors: any;
  placeholder?: string;
  disableFields: boolean;
};

export const InputCheckBoxForm = ({
  name,
  label,
  control,
  errors,
  placeholder,
  disableFields,
}: InputFormProps) => {
  return (
    <div className="form-check">
      <input
        placeholder={placeholder}
        type={"checkbox"}
        disabled={disableFields}
        className={`form-check-input  ${
          errors?.[`${name}`] ? "is-invalid" : ""
        }`}
        {...control.register(name)}
      />
      <label htmlFor={name} className="form-check-label">
        {label}
      </label>
      {errors?.[`${name}`] && (
        <span className="invalid-feedback d-block">
          {errors?.[`${name}`].message}
        </span>
      )}
    </div>
  );
};
