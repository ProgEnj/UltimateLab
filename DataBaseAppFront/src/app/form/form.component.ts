import { NgFor } from '@angular/common';
import { Component, Input, output, OnChanges, SimpleChanges } from '@angular/core';
import { ReactiveFormsModule, FormGroup, Validators, FormBuilder, FormsModule } from '@angular/forms';

@Component({
  selector: 'app-form',
  standalone: true,
  imports: [ReactiveFormsModule, NgFor, FormsModule],
  templateUrl: './form.component.html',
  styleUrl: './form.component.scss'
})
export class FormComponent implements OnChanges {
  constructor(private fb: FormBuilder) {}

  @Input() fields: Array<any> = [];

  formData = output<any>();
  form = new FormGroup({});

  whereOption: string = "";
  whereValue: string = "";
  whereField = output<string>();

  onSubmit(event: any) {
    this.formData.emit(this.form.getRawValue());
    this.whereField.emit(`${this.whereOption}='${this.whereValue}'`);
  }

  onWhereField(event: any) {
    this.whereOption = event.target.value;
  }

  ngOnChanges(changes: SimpleChanges): void {
    this.form = this.fb.group({});
    this.fields = this.fields.filter(x => x.label !== "id");
    this.fields.filter(x => x.isShown !== false).forEach(x => {this.form.addControl(x.label, this.fb.control('', Validators.required))})
  }
}
