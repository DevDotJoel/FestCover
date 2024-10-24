export type InputFormProps = {
  name: string;
  label: string;
  control: any;
  errors: any;
  type: "text" | "number" | "password" | "email" | "color" | "date";
  placeholder?: string;
  disableFields: boolean;
};

export const InputForm = ({
  name,
  label,
  control,
  type,
  errors,
  placeholder,
  disableFields,
}: InputFormProps) => {
  return (
    <>
      {" "}
      <label htmlFor={name} className="form-label">
        {label}
      </label>
      <input
        placeholder={placeholder}
        type={type}
        disabled={disableFields}
        className={`form-control rounded-3 ${
          errors?.[`${name}`] ? "is-invalid" : ""
        }`}
        {...control.register(name)}
      />
      {errors?.[`${name}`] && (
        <span className="invalid-feedback d-block">
          {errors?.[`${name}`].message}
        </span>
      )}
    </>
  );
};
