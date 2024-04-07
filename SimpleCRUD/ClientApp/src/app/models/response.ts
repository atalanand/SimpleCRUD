export class Response {
  status: number;
  message: string;
}
export class ResponseData<T> extends Response {
  object: T;
  list: T[]
}
