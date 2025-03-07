<template>
  <main>
    <el-button type="primary" plain @click="toggleDialog"> Add Note </el-button>
    <el-table v-loading="loading" :data="Notes" style="width: 100%">
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
      loading: false,
    }
  },
  methods: {
    toggleDialog() {
      this.dialogFormVisible = !this.dialogFormVisible
    },
    submitNote() {
      this.loading = true
      axios.post(apiUrl, this.noteCreationDto)
      this.toggleDialog()
      setTimeout(() => {
        this.loadNote()
      }, 1000)
      Object.keys(this.noteCreationDto)
        .forEach((key) => {
          this.noteCreationDto[key] = ''
        })
        .finally(() => {
          this.loading = false
        })
    },
    loadNote() {
      this.loading = true
      axios
        .get(apiUrl)
        .then((res) => {
          console.log(res)
          this.Notes = res.data
        })
        .catch(() => {
          this.Notes = []
        })
        .finally(() => {
          this.loading = false
        })
    },
    deleteNote(guid) {
      this.loading = true
      axios.delete(apiUrl + '?guid=' + guid, this.noteCreationDto)
      setTimeout(() => {
        this.loadNote()
      }, 1000).finally(() => {
        this.loading = false
      })
    },
  },
  mounted() {
    this.loadNote()
  },
}
</script>
