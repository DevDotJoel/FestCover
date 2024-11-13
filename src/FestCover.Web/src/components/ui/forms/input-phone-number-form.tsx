import { Controller } from "react-hook-form";
import PhoneInput from "react-phone-input-2";
export type IInputPhoneNumberFormProps = {
  name: string;
  label: string;
  control: any;
  errors: any;
  placeholder?: string;
  disableFields: boolean;
};

export const InputPhoneNumberForm = ({
  name,
  label,
  control,
  errors,
  placeholder,
  disableFields,
}: IInputPhoneNumberFormProps) => {
  return (
    <>
      <label htmlFor={name} className="form-label">
        {label}
      </label>
      <Controller
        name={name}
        control={control}
        disabled={disableFields}
        render={({ field: { onChange, value } }) => (
          <PhoneInput
            inputClass={`rounded-3 ${errors?.[`${name}`] ? "is-invalid" : ""}`}
            placeholder={placeholder}
            value={value}
            onChange={onChange}
            country={"pt"}
            copyNumbersOnly={false}
          />
        )}
      />
      {errors?.[`${name}`] && (
        <span className="invalid-feedback d-block">
          {errors?.[`${name}`].message}
        </span>
      )}
    </>
  );
};
