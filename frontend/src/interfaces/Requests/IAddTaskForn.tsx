export interface IAddTaskForm {
  Name: string;
  Description?: string;
  Due: Date;
  Group_Id: string;
  Status: [0, 1, 2, 3]
}