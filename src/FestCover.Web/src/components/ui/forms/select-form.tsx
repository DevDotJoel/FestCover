export type SelectFormOptions = {
  name: string;
  value: number | string;
};

export type SelectFormProps = {
  name: string;
  label: string;
  control: any;
  errors: any;
  placeholder?: string;
  options: SelectFormOptions[];
};

export const SelectForm = ({
  name,
  label,
  control,
  errors,
  placeholder,
  options,
}: SelectFormProps) => {
  return (
    <>
      <label htmlFor={name} className="form-label">
        {label}
      </label>
      <select
        className={`form-select rounded-3 ${
          errors?.[`${name}`] ? "is-invalid" : ""
        }`}
        {...control.register(name)}
        placeholder={placeholder}
      >
        <option key={-1} value={null}></option>
        {options.map((option: SelectFormOptions, index: number) => {
          return (
            <option key={index} value={option.value}>
              {option.name}
            </option>
          );
        })}
      </select>
      {errors?.[`${name}`] && (
        <span className="invalid-feedback d-block">
          {errors?.[`${name}`].message}
        </span>
      )}
    </>
  );
};
