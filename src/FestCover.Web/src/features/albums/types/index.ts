export interface AlbumModel {
  id: string;
  name: string;
  key: string;
  description: string;
  url: string;
  isPublic: boolean;
  allowPublicUpload: boolean;
  reviewUploadedContent: boolean;
}
export interface AlbumContentPendingModel {
  id: string;
  albumName: string;
  albumId: string;
  description: string;
  url: string;
  name: string;
  email?: string;
  date: string;
}

export interface AlbumContentModel {
  id: string;
  phoneNumber?: string;
  url: string;
}

export interface CreateAlbumModel {
  name: string;
  description: string;
  albumImage: File;
  isPublic: boolean;
  allowPublicUpload: boolean;
  public: boolean;
  reviewUploadedContent: boolean;
}
export interface UpdateAlbumModel {
  albumId: string;
  name: string;
  description: string;
  albumImage?: File;
  isPublic: boolean;
  allowPublicUpload: boolean;
  reviewUploadedContent: boolean;
}
export interface CreateAlbumContentModel {
  albumId: string;
  albumContentImages: File[];
}

export interface AlbumDetailModel {
  id: string;
  name: string;
  url: string;
  allowPublicUpload: boolean;
  contents: AlbumContentModel[];
}
export interface CreateAlbumContentPublicModel {
  email: string;
  name: string;
  albumId: string;
  albumContentImages: File[];
}

export interface ApproveAlbumContentModel {
  albumContentId: string;
}

export interface RejectAlbumContentModel {
  albumContentId: string;
}
