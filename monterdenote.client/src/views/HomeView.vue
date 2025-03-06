<template>
  <main>
    <el-button type="primary" plain @click="toggleDialog"> Add Note </el-button>
    <el-table :data="Notes" style="width: 100%">
      <el-table-column prop="title" label="Name" />
      <el-table-column prop="content" label="Content" />
      <el-table-column fixed="right" label="Operations">
        <template #default="{ row }">
          <el-button type="danger" size="small" @click="deleteNote(row.guid)"> Delete </el-button>
        </template>
      </el-table-column>
    </el-table>
    <!--Dialog below-->
    <el-dialog v-model="dialogFormVisible" title="Add Note" width="500">
      <el-form :model="noteCreationDto">
        <el-form-item label="Name" label-position="top" :label-width="formLabelWidth">
          <el-input v-model="noteCreationDto.title" autocomplete="off" />
        </el-form-item>
        <el-form-item label="Content" label-position="top" :label-width="formLabelWidth">
          <el-input v-model="noteCreationDto.content" type="textarea" autocomplete="off" />
        </el-form-item>
      </el-form>
      <template #footer>
        <div class="dialog-footer">
          <el-button @click="toggleDialog">Cancel</el-button>
          <el-button type="primary" @click="submitNote"> Confirm </el-button>
        </div>
      </template>
    </el-dialog>
  </main>
</template>

<script>
import axios from 'axios'
const apiUrl = 'https://monterdenote-api-gyhzf8hgeyfeeghz.eastasia-01.azurewebsites.net/api/Note'
export default {
  data() {
    return {
      noteCreationDto: {
        title: '',
        content: '',
      },
      Notes: [],
      dialogFormVisible: false,
      formLabelWidth: '140px',
    }
  },
  methods: {
    toggleDialog() {
      this.dialogFormVisible = !this.dialogFormVisible
    },
    submitNote() {
      axios.post(apiUrl, this.noteCreationDto)
      this.toggleDialog()
      setTimeout(() => {
        this.loadNote()
      }, 1000)
      Object.keys(this.noteCreationDto).forEach((key) => {
        this.noteCreationDto[key] = ''
      })
    },
    loadNote() {
      axios
        .get(apiUrl)
        .then((res) => {
          console.log(res)
          this.Notes = res.data
        })
        .catch(() => {
          this.Notes = []
        })
    },
    deleteNote(guid) {
      axios.delete(apiUrl + '?guid=' + guid, this.noteCreationDto)
      this.toggleDialog()
      setTimeout(() => {
        this.loadNote()
      }, 1000)
    },
  },
  mounted() {
    this.loadNote()
  },
}
</script>
