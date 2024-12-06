import { AssignmentAttachment } from "./assignmentAttachment";
import { AssignmentComment } from "./assignmentComment";

export interface ITask {
  id:number,
  title: string,
  description: string,
  priority: string,
  status: string,
  dueDate: Date,
  userName: string,
  assignmentComments: AssignmentComment[],
  assignmentAttachments: AssignmentAttachment[]
}
