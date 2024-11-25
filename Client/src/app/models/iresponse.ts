export interface IResponse<T> {
  statusCode: number,
  meta: object,
  succeeded: boolean,
  message: string,
  errors: string[],
  data: T
}
