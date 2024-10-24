import { useRef } from "react";

export interface IFileImporterProps {
  output: (file: any) => void;
  message: string;
  allowedExtensions: string;
  icon?: string;
}

export const FileImporter = (props: IFileImporterProps) => {
  const fileRef = useRef<any>(null);

  const handleChange = (e: any) => {
    const [file] = e.target.files;
    fileToDataUri(file).then(async (previewLink: any) => {
      props.output({
        file: file,
        filePreviewLink: previewLink,
      });
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
        className="btn btn-dark rounded-5 "
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
        multiple={false}
        type="file"
        hidden
      />
    </>
  );
};
