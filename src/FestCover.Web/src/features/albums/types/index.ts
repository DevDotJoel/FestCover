export interface AlbumModel {
  id: string;
  name: string;
  key: string;
  description: string;
  url: string;
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

export interface AlbumDetailModel {
  id: string;
  name: string;
  url: string;
  contents: AlbumContentModel[];
}
