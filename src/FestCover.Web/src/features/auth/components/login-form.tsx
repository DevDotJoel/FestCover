import { useForm } from "react-hook-form";
import { zodResolver } from "@hookform/resolvers/zod";
import { InputForm } from "../../../components/ui/forms/input-form";
import { z } from "zod";

export interface LoginFormProps {
  onSubmit: (data: FormFields) => void;

  disableFields: boolean;
}
const loginSchema = z.object({
  email: z.string().email(),
  password: z.string().min(5),
});
type FormFields = z.infer<typeof loginSchema>;

export const LoginForm = ({ onSubmit, disableFields }: LoginFormProps) => {
  const {
    control,
    handleSubmit,
    formState: { errors },
  } = useForm<FormFields>({
    defaultValues: undefined,
    resolver: zodResolver(loginSchema),
  });

  return (
    <>
      <form onSubmit={handleSubmit(onSubmit)}>
        <div className="row mt-2">
          <div className="col">
            <InputForm
              name="email"
              label="Email"
              type="email"
              control={control}
              errors={errors}
              disableFields={disableFields}
            />
          </div>
        </div>
        <div className="row mt-2">
          <div className="col">
            <InputForm
              name="password"
              label="Password"
              type="password"
              control={control}
              errors={errors}
              disableFields={disableFields}
            />
          </div>
        </div>
        <div className="row mt-3">
          <div className="col ">
            <div>
              <button
                disabled={disableFields}
                type="submit"
                className="btn btn-blue rounded-5 w-100"
              >
                Sign In
              </button>
            </div>
          </div>
        </div>
      </form>
    </>
  );
};
