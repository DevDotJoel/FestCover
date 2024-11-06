import { useRef } from "react";
import { toast } from "react-toastify";

export interface IFileImporterProps {
  output: (files: any[]) => void;
  message: string;
  allowedExtensions: string;
  icon?: string;
  allowMultiple: boolean;
}

export const FileImporter = (props: IFileImporterProps) => {
  const MAX_LENGTH = 20;
  const fileRef = useRef<any>(null);

  const handleChange = (e: any) => {
    if (Array.from(e.target.files).length > MAX_LENGTH) {
      toast.error(`Cannot upload more than${MAX_LENGTH}`);
      return;
    }
    const files = Array.from(e.target.files);
    Promise.all(files.map(fileToDataUri)).then((filePreviews) => {
      const outputFiles = files.map((file, index) => ({
        file,
        filePreviewLink: filePreviews[index],
      }));

      props.output(outputFiles);
      e.target.value = null;
    });
  };
  function uploud() {
    if (fileRef.current) {
      fileRef.current.click();
    }
  }
  const fileToDataUri = (file: any) =>
    new Promise((resolve) => {
      const reader = new FileReader();
      reader.onload = async (event: any) => {
        const response = await fetch(event.target.result);
        const blob = await response.blob();
        const filePreviewLink = URL.createObjectURL(blob);
        resolve(filePreviewLink);
      };
      reader.readAsDataURL(file);
    });

  return (
    <>
      <button
        className="btn btn-blue rounded-5 "
        type="button"
        onClick={uploud}
      >
        {props.icon && (
          <>
            <i className={props.icon}></i>
          </>
        )}
        {props.message}
      </button>
      <input
        accept={props.allowedExtensions}
        ref={fileRef}
        onChange={handleChange}
        multiple={props.allowMultiple}
        type="file"
        hidden
      />
    </>
  );
};
