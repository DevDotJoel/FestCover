export interface AuthUserModel {
  id: string;
  email: string;
  username: string;
  pictureUrl?:string
}
export interface UpdateAuthUserModel{
  username:string;
  email:string;
  currentPassword?:string,
  password?:string,
  password2?:string,
  file?:File
}