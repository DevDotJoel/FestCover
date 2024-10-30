export interface AlbumModel {
  id: string;
  name: string;
  key:string;
  description: string;
  albumUrlImage: string;
  originalAlbumUrlImage: string;
  smallAlbumUrlImage: string;
  mediumAlbumUrlImage: string;
  largeAlbumUrlImage: string;
}

export interface AlbumContentModel {
  id: string;
  phoneNumber: string;
  originalAlbumContentUrlImage: string;
  smallAlbumContentUrlImage: string;
  mediumAlbumContentUrlImage: string;
  largeAlbumContentUrlImage: string;
}

export interface CreateAlbumModel {
  name: string;
  description: string;
  albumImage: File;
}
export interface UpdateAlbumModel {
  albumId: string;
  name: string;
  description: string;
  albumImage?: File;
}
export interface CreateAlbumContentModel {
  albumId: string;
  albumContentImage: File;
}
