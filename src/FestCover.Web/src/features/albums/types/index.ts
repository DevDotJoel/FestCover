export interface AlbumModel {
  id: string;
  name: string;
  description: string;
  albumUrlImage: string;
}

export interface AlbumContentModel {
  id: string;
  albumId: string;
  phoneNumber: string;
  url: string;
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
