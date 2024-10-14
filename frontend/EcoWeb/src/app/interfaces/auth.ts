export interface RegisterPostData {
  nome: string;
  senha: string;
}

export interface User extends RegisterPostData {
  id: string;
}