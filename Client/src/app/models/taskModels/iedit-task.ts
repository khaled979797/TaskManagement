import { Priority } from "../enums/priority";
import { Status } from "../enums/status";

export interface IEditTask {
  id:number,
  title: string,
  description: string,
  priority: number,
  status: number,
  dueDate: Date,
  userId: number
}
