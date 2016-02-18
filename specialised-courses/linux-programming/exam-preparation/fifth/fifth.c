#include <linux/kernel.h>
#include <linux/init.h>
#include <linux/module.h>
#include <linux/seq_file.h>
#include <linux/proc_fs.h>

static int print_something(struct seq_file *m, void *v) {
	seq_printf(m, "Hello. It's me\n");
	return 0;
}

static int file_open_proc(struct inode * inode, struct file * file) {
	return single_open(file, print_something, NULL);
}

struct proc_dir_entry * proc_file_entry;

static const struct file_operations proc_file_ops = {
	.owner = THIS_MODULE,
	.open = file_open_proc,
	.read = seq_read,
	.llseek = seq_lseek,
	.release = single_release
};

static int __init init(void) {
	proc_file_entry = proc_create("dummy_file", 0, NULL, &proc_file_ops);
	if (proc_file_entry == NULL) {
		return -ENOMEM;
	}

	return 0;
}

static void __exit cleanup(void) {
	remove_proc_entry("dummy_file", NULL);
	printk(KERN_ERR "Goodbye\n");
}

module_init(init);
module_exit(cleanup);
